import React from 'react';
import {
  BrowserRouter as Router,
  Route,
  Link
} from "react-router-dom";
import Index from './pages/players/Index';
import AddPlayer from './pages/players/AddPlayer';
import EditPlayer from './pages/players/EditPlayer';
import DeletePlayer from './pages/players/DeletePlayer';
import Proba from './pages/players/Proba';

export default function App(){
  return(
    <Router>

      <nav className="navbar navbar-expand-lg navbar-light bg-light">
      <div className="container-fluid">
        <ul className="navbar-nav me-auto mb-2 mb-lg-0">
          <li className="nav-item">
            <Link to="/" className="nav-link active">Home</Link>
          </li>
          <li className="navbar-item">
            <Link to="/add" className="nav-link">Create</Link>
          </li>
        </ul>
      </div>

      </nav>
        <div>
            <Route exact path={["/", "/players"]} component={Index}/>
            <Route path="/add" component={AddPlayer}/>
            <Route path="/edit/:id" component={EditPlayer}/>
            <Route path="/delete/:id" component={DeletePlayer}/>
            <Route path="/proba" component={Proba}/>
        </div>
    </Router>
  )
}


