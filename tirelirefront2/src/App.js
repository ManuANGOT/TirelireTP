import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'; // Importez Routes
import logo from './Images/0016.jpg';
import AppNavbar from './Pages/AppNavbar';
import CustomerPage from './Pages/CustomerPage';
import AdminPage from './Pages/AdminPage';
import ModPage from './Pages/ModPage';
import AssistPage from './Pages/AssistPage';
import 'bootstrap/dist/css/bootstrap.min.css';
import './index.css';

function App() {
    return (
        <Router>
            <div className="App">
                <header>
                    <AppNavbar />
                </header>

                <main>
                    <img src={logo} className="App-logo" alt="logo" />
                    <p>
                        Bienvenue dans l'application Piggy-Coins !
                    </p>
                </main>

             

                <Routes> 
                    <Route path="/Customer" element={<CustomerPage />} />
                    <Route path="/Admin" element={<AdminPage />} />
                    <Route path="/Mod" element={<ModPage />} />
                    <Route path="/Assist" element={<AssistPage />} />
                </Routes>
            </div>
            <footer>
                    TP GK - 2023
            </footer>
        </Router>
    );
}

export default App;
