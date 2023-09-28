import React, { useState } from 'react';
import { Link } from 'react-router-dom';

function EShopPage() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleEmailChange = (e) => {
        setEmail(e.target.value);
    };

    const handlePasswordChange = (e) => {
        setPassword(e.target.value);
    };

    const handleSubmit = (e) => {
        e.preventDefault();


        console.log('Email:', email);
        console.log('Password:', password);
    };

    return (
        <div>
            <h1> E-Boutique </h1>
            <p>Déjà client ? Veuillez vous authentifier :</p>
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="email">Email: </label>
                    <input
                        type="email"
                        id="email"
                        name="email"
                        value={email}
                        onChange={handleEmailChange}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="password">Password: </label>
                    <input
                        type="password"
                        id="password"
                        name="password"
                        value={password}
                        onChange={handlePasswordChange}
                        required
                    />
                </div>
                <button type="submit">Validation</button>
            </form>
            <Link to="/Registration">Inscription</Link> {/* Ajoutez ce bouton d'inscription */}
        </div>
    );
}

export default EShopPage;