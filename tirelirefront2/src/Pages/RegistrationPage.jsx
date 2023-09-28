/* eslint-disable no-undef */
import React, { useState } from 'react';

function RegistrationPage() {
    const [formData, setFormData] = useState({
        Name: '',
        Firstname: '',
        Birthday: '',
        Email: '',
        Password: '',
        ConfirmPassword: '',
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({
            ...formData,
            [name]: value,
        });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        // Ajoutez ici la logique de validation et de soumission du formulaire

        if (formData.password !== formData.confirmPassword) {
            alert("Les mots de passe ne correspondent pas !");
        } else {
            // Soumettez le formulaire
            console.log("Formulaire soumis :", formData);
        }
    };

    return (
        <div>
            <h1>Inscription</h1>
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="name">Nom : </label>
                    <input
                        type="text"
                        id="name"
                        name="name"
                        value={formData.name}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="firstName">Prénom : </label>
                    <input
                        type="text"
                        id="firstName"
                        name="firstName"
                        value={formData.firstName}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="birthday">Date de naissance : </label>
                    <input
                        type="date"
                        id="birthday"
                        name="birthday"
                        value={formData.birthday}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="email">Email : </label>
                    <input
                        type="email"
                        id="email"
                        name="email"
                        value={formData.email}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="password">Mot de passe : </label>
                    <input
                        type="password"
                        id="password"
                        name="password"
                        value={formData.password}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="confirmPassword">Confirmer le mot de passe : </label>
                    <input
                        type="password"
                        id="confirmPassword"
                        name="confirmPassword"
                        value={formData.confirmPassword}
                        onChange={handleChange}
                        required
                    />
                </div>
                <button type="submit">Validation</button>
            </form>
        </div>
       
    );
    // test

    console.log('Name:', Name);
    console.log('FirstName:', FirstName);
    console.log('Birthday:', Birthday);
    console.log('Email:', Email);
    console.log('Password:', Password);
    console.log('Confirm Password:', ConfirmPassword);

 
}


export default RegistrationPage;
