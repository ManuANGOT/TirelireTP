import logo from './Images/0016.jpg';
import React from 'react';
import AppNavbar from './NavBar/AppNavbar';

function App() {
    return (
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

            <footer>
                <p>
                    TP GK - 2023
                </p>
            </footer>

        </div>
    );
}

export default App;