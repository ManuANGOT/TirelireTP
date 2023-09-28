import React from 'react';
import { Navbar, Nav, NavDropdown } from 'react-bootstrap';
import AdminPage from './AdminPage';
import AssistPage from './AssistPage';
import CustomerPage from './CustomerPage';
import ModPage from './ModPage';
import ProductPage from './ProductPage';


function AppNavbar() {
    // 'userRole' = rôle de l'utilisateur
    let userRole = 'Customer';
    // Authentification de l'utilisateur
    const isLoggedIn = true;
    const isAdmin = true;
    const isMod = true;
    const isAssist = true;

    if (isLoggedIn) {
        if (isAdmin === true && userRole !== null) {
            userRole = 'Admin';
        } else if (isMod === true && userRole !== null) {
            userRole = 'Mod';
        } else if (isAssist === true && userRole !== null) {
            userRole = 'Assist';
        }
    }

    return (
        <Navbar bg="light" expand="lg">
            <Navbar.Brand href="/">Piggy's Coins</Navbar.Brand>
            <Navbar.Toggle aria-controls="basic-navbar-nav" />
            <Navbar.Collapse id="basic-navbar-nav">
                <Nav className="mr-auto">
                    {isLoggedIn && <Nav.Link href="/shop">Nos produits</Nav.Link>}
                </Nav>
                <Nav>
                    {/* NavDropdown pour créer le menu déroulant */}
                    {isLoggedIn && (
                        <NavDropdown title={`Espace ${userRole}`} id="basic-nav-dropdown">
                            <NavDropdown.Item href="/Customer"> Client </NavDropdown.Item>
                            <NavDropdown.Item href="/Admin"> Administration </NavDropdown.Item>
                            <NavDropdown.Item href="/Mod"> Moderateur </NavDropdown.Item>
                            <NavDropdown.Item href="/Assist"> Assistant </NavDropdown.Item>
                        </NavDropdown>
                    )}
                </Nav>
            </Navbar.Collapse>
        </Navbar>
    );
}

export default AppNavbar;
