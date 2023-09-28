import React, { useState } from 'react';

function AssistPage() {
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

        // Vous pouvez ajouter ici la logique de validation du formulaire
        // Par exemple, envoyer les données au serveur ou effectuer une vérification côté client.
        // Pour cet exemple, nous allons simplement afficher les valeurs entrées.

        console.log('Email:', email);
        console.log('Password:', password);
    };

    return (
        <div>
            <h1>Espace Assistance</h1>
            <p>Veuillez vous authentifier :</p>
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
        </div>
    );
}

export default AssistPage;