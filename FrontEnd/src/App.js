import React from 'react';
import logo from './logo.svg';
import './App.css';
import { store } from "./actions/store";
import { Provider } from "react-redux";
import DCandidates from './components/DProduct';
import { Container } from "@material-ui/core";
import { ToastProvider } from "react-toast-notifications";
import DProduct from './components/DProduct';
//render component
function App() {
  return (
    <Provider store={store}>
        <Container maxWidth="lg">
          
        <DProduct />
          
        </Container>
    </Provider>
  );
}

export default App;
