//import actions 
import { ACTION_TYPES } from "../actions/dProduct";
const initialState = {
    list: []
}


export const dProduct = (state = initialState, action) => {
//switch case for actions 
    switch (action.type) {
        //fetch operation 
        case ACTION_TYPES.FETCH_ALL:
            return {
                ...state,
                list: [...action.payload]
            }

    /*    case ACTION_TYPES.CREATE:
            return {
                ...state,
                list: [...state.list, action.payload]
            }

        case ACTION_TYPES.UPDATE:
            return {
                ...state,
                list: state.list.map(x => x.id == action.payload.id ? action.payload : x)
            }

        case ACTION_TYPES.DELETE:
            return {
                ...state,
                list: state.list.filter(x => x.id != action.payload)
            }*/
            
        default:
            return state
    }
}