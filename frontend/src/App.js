import React from 'react';

import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';

import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import CardList from './CardList';
import CreateCard from './CreateCard';


function App() {
  return (
    <Router>
      <nav className="navbar navbar-expand-lg navbar-light bg-light">
        <div className="container-fluid">
          <a className="navbar-brand" href="/">Карточки</a>
          <div className="collapse navbar-collapse" id="navbarNav">
            <ul className="navbar-nav">
              <li className="nav-item">
                <Link to="/" className="nav-link">Главная</Link>
              </li>
              <li className="nav-item">
                <Link to="/add" className="nav-link">Добавление</Link>
              </li>
            </ul>
          </div>
        </div>
      </nav>

      <main>
        <Routes>
          <Route path="/add" element={<CreateCard />} />
          <Route path="/" element={<CardList />} />
        </Routes>
      </main>
    </Router >
  );
}

export default App;
