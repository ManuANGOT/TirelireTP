
import React from 'react';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import { Switch } from 'react-router-dom';
import logo from './Images/0016.jpg';
import AppNavbar from './NavBar/AppNavbar';
import CustomerPage from './Views/CustomerPage.jsx';
import AdminPage from './Views/AdminPage.jsx';        
import ModPage from './Views/ModPage.jsx';             
import AssistPage from './Views/AssistPage.jsx'; 

function App() {
    return (
        <Router>
        <div className="App">
        
                <header>
                    <AppNavbar />
                    <Switch>
                        <Route path="/Customer" component={CustomerPage} />
                        <Route path="/Admin" component={AdminPage} />
                        <Route path="/Mod" component={ModPage} />
                        <Route path="/Assist" component={AssistPage} />
                    </Switch>
                </header>

            <main>
                <img src={logo} className="App-logo" alt="logo" />
                <p>
                    Bienvenue dans l'application Piggy-Coins !
                </p>
            </main>

            <footer>
                
                    TP GK - 2023
                
            </footer>

        </div>
        </Router >
    );
}

export default App;