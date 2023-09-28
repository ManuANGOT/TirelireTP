import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import AppNavbar from './Pages/AppNavbar';
import CustomerPage from './Pages/CustomerPage';
import AdminPage from './Pages/AdminPage';
import ModPage from './Pages/ModPage';
import AssistPage from './Pages/AssistPage';
import RegistrationPage from './Pages/RegistrationPage';
import 'bootstrap/dist/css/bootstrap.min.css';
import './index.css';
import ProductPage from './Pages/ProductPage';
import EShopPage from './Pages/EShopPage';
import Carousel from 'react-bootstrap/Carousel';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/css/bootstrap.css';

// images du carrousel
import image1 from './Images/0020.jpg';
import image2 from './Images/0002.jpg';
import image3 from './Images/0003.jpg';
import image4 from './Images/0004.jpg';
import image5 from './Images/0005.jpg';
import image6 from './Images/0006.jpg';
import image7 from './Images/0021.jpg';
import ShoppingCartPage from './Pages/ShoppingCartPage';

function App() {
    return (
        <Router>
            <div className="App">
                <header>
                    <AppNavbar />
                </header>

                <main>
                    <p>
                        Bienvenue dans l'application Piggy-Coins !
                    </p>
                    <Routes>
                        <Route path="/Products" element={<ProductPage />} />
                        <Route path="/EShop" element={<EShopPage />} />
                        <Route path="/Customer" element={<CustomerPage />} />
                        <Route path="/Admin" element={<AdminPage />} />
                        <Route path="/Mod" element={<ModPage />} />
                        <Route path="/Assist" element={<AssistPage />} />
                        <Route path="/Registration" element={<RegistrationPage />} />
                        <Route path="/ShoppingCart" element={<ShoppingCartPage />} />
                    </Routes>
                    <Carousel>
                        <Carousel.Item>
                            <img src={image1} alt="Image 1" className="carousel-image" />
                        </Carousel.Item>
                        <Carousel.Item>
                            <img src={image2} alt="Image 2" className="carousel-image" />
                        </Carousel.Item>
                        <Carousel.Item>
                            <img src={image3} alt="Image 3" className="carousel-image" />
                        </Carousel.Item>
                        <Carousel.Item>
                            <img src={image4} alt="Image 4" className="carousel-image" />
                        </Carousel.Item>
                        <Carousel.Item>
                            <img src={image5} alt="Image 5" className="carousel-image" />
                        </Carousel.Item>
                        <Carousel.Item>
                            <img src={image6} alt="Image 6" className="carousel-image" />
                        </Carousel.Item>
                        <Carousel.Item>
                            <img src={image7} alt="Image 7" className="carousel-image" />
                        </Carousel.Item>
                    </Carousel>

                    
                </main>
             
            </div>
            <footer>
                TP GK - 2023
            </footer>
        </Router>
    );
}

export default App;
