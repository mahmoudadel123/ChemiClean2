import React ,{useState , useEffect} from "react";
import {connect} from "react-redux";
import  SaveIcon  from "@material-ui/icons/Save";
import { Container ,ButtonGroup,Button,  Grid , Paper ,TableContainer, Table ,  TableRow , TableHead , TableBody , TableCell  } from "@material-ui/core";
import * as actions from "../actions/dProduct";

const DProduct=(props)=>{

  //fetch all data from the api 
  useEffect(()=>{
props.fetchAllDProduct()
  },[])
  //set time to change if online files are different than local files 
  //if and only if it's downloaded
  useEffect(() => {
    const timer = setTimeout(() => {
     props.CheckVersion();
    }, 10000);
    return () => clearTimeout(timer);
  }, []);
  //save file to local database
  const onSaveLocal = id => {
   
        props.SaveToLocal(id);
        ;
}
//render the data body
  return (
    <Paper>
<Grid container >

  <Grid item >
    <TableContainer>
     <Table>
       <TableHead>
         <TableRow>
         <TableCell>Product Name</TableCell>
         <TableCell>Supplier Name</TableCell>
         <TableCell>Url</TableCell>
         <TableCell>Local Avilablity</TableCell>
         <TableCell>Options</TableCell>
         </TableRow>
       </TableHead>
       <TableBody >
         {
           
           props.dProductlist.map((record,index)=>{
             //notifiy user which files are exist in database
             //give avilable data green color and give unavilable red color
            var avl="";
            var stcolor="";
            if (record.localFile!=null && record.localFile!='') {
                  avl="avilable in local database"
                  stcolor="green !important";
            }
            else{
               avl="not avilable in local database"
               stcolor="red !important";

            }
             return(<TableRow key={index}>
               <TableCell>{record.productName}</TableCell>
               <TableCell>{record.supplierName}</TableCell>
               <TableCell><a target='_blank' href={record.url}>{record.url}</a></TableCell>
               <TableCell style={{color: stcolor}}><a target='_blank' onClick={() => base64ToArrayBuffer(record.localFile)}  href="">{avl}</a></TableCell>
              
               <TableCell>
                 <ButtonGroup>
                   <Button><SaveIcon onClick={() => onSaveLocal(record.id)} color="primary"></SaveIcon></Button>
                 </ButtonGroup>
               </TableCell>
             </TableRow>)
           })
         }
       </TableBody>
     </Table>   
  
   </TableContainer>
  </Grid>
</Grid>
</Paper>
  )
}
//map states
const mapStateToProps=state=>{
    return{
        dProductlist:state.dProduct.list ,
        dResponse:state.dProduct.SaveToLocal
    }
}
//map actions
const mapActionToProps={
    fetchAllDProduct:actions.fetchAll ,
    SaveToLocal:actions.SaveToLocal,
    CheckVersion :actions.CheckVersion 
}

//Convert binary data to binary array to be able to download local files 

function base64ToArrayBuffer(base64) {
  if(base64==null || base64=='')
  return;
  var binaryString = window.atob(base64);
  var binaryLen = binaryString.length;
  var bytes = new Uint8Array(binaryLen);
  for (var i = 0; i < binaryLen; i++) {
     var ascii = binaryString.charCodeAt(i);
     bytes[i] = ascii;
  }
  Download('new',bytes);
}
//download binary data it supposed to work only with pdf

function Download(reportName, byte) {
  var blob = new Blob([byte], {type: "application/pdf"});
    var link = document.createElement('a');
    link.href = window.URL.createObjectURL(blob);
    var fileName = reportName;
    link.download = fileName;
    link.click();
}
export default connect(mapStateToProps,mapActionToProps)(DProduct);