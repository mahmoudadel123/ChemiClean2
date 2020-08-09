//import the reducers and pass the object of all reducers

import { combineReducers } from "redux";
import { dProduct } from "./dProduct";

export const reducers = combineReducers({
    dProduct
})