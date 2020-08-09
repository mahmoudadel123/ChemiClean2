import api from "./api";

//constant just to define operations we have in the app  
export const ACTION_TYPES = {
    CheckVersion: 'CheckVersion',
    SaveToLocal: 'SaveToLocal',
    FETCH_ALL: 'FETCH_ALL'
}


// fetch all funtion 
export const fetchAll = () => dispatch => {
    //get api request
    //if it success it will go to call back funtion
    //if else it will go for catch 
    api.dProduct().fetchAll()
        .then(response => {
            dispatch({
                type: ACTION_TYPES.FETCH_ALL,
                payload: response.data.data
            })
        })
        //i just log the error to the console 
        .catch(err => console.log(err))
}

//save funtion 
 export const SaveToLocal = (id, onSuccess) => dispatch => {
     api.dProduct().SaveLocal(id)
         .then(res => {
             dispatch({
                 type: ACTION_TYPES.SaveToLocal,
                 payload: id
             },
             checkresult(res.data.isDone)
            
             )
             
         } )
         .catch(err => console.log(err))
 }
 //check if file saved or not 
 const checkresult=(isDone)=>
{
    if(isDone==false)
    {
        window.alert("file is not avilable")
    }
    else{
        window.location.reload()
    }
}
//check if version is different
 export const CheckVersion = (onSuccess) => dispatch => {
    api.dProduct().CheckVersion()
        .then(response => {
            dispatch({
                type: ACTION_TYPES.CheckVersion,
                payload: response.data
            },
            window.alert(response.data.result.message)
            )
            
        } )
        .catch(err => console.log(err))
}
 