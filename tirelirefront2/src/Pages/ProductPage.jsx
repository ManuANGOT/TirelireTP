import React, { useEffect, useState } from 'react';
import axios from 'axios';

function ProductPage() {
    const [products, setProducts] = useState([]);

    useEffect(() => {
        // Faire une requête GET pour récupérer les données des produits depuis votre API
        axios.get('/api/products')  // Remplacez '/api/products' par l'URL de votre API
            .then((response) => {
                setProducts(response.data);
            })
            .catch((error) => {
                console.error('Erreur lors de la récupération des produits', error);
            });
    }, []);

    return (
        <main>
            <div>
                <h1>Produits</h1>
                <p>Découvrez notre gamme !</p>
            </div>
            <div>
                {/* Produits */}
                {products.map((product) => (
                    <div key={product.productId}>
                        <h2>{product.productName}</h2>
                        <p>{product.productDescription}</p>
                        <p>{product.productHeight}</p>
                        <p>{product.productWidth}</p>
                        <p>{product.productWeight}</p>
                        <p>{product.productLenght}</p>
                        <p>{product.productColour}</p>
                        <p>{product.productCapacity}</p>
                        <p>{product.productMaker}</p>
                        <p>{product.productImage}</p>
                        <p>{product.productPrice}</p>
                        <p>{product.productQuantity}</p>
                    </div>
                ))}
            </div>
        </main>
    );
}

export default ProductPage;