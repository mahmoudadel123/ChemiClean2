//http requests

import axios from "axios";

//base ur 

const baseUrl = "https://localhost:44384/api/"



export default {

    dProduct(url = baseUrl + 'Products/') {
        return {
            // fetch all data 
            fetchAll: () => axios.get(url+'Get'),
            //check if local version is different that online
            CheckVersion: () => axios.get(url+'CheckVersion'),
            //save local copy in the database
            SaveLocal: id => axios.get(url+'Savelocalversion/'+id)
        }
    }
}