import React from "react";
import { Link } from "react-router-dom";

export default class UserRow extends React.Component<any,any>{

    public render(){
    return(
        <tr>
            <td scope="row" >{this.props.player.id}</td>
            <td scope="row" >{this.props.player.firstName}</td>
            <td scope="row" >{this.props.player.lastName}</td>
            <td scope="row" >{this.props.player.managerName}</td>
            <td scope="row" >{this.props.player.clubName}</td>
            <td>
                <div className="btn-group" role="group">
                    <Link to={`/edit/${this.props.player.id}`} className="nav-link">
                                <button type="button" className="btn btn-primary btn-sm">
                                    Edit</button>
                    </Link>
                    <Link to={`/delete/${this.props.player.id}`} className="nav-link">
                                <button type="button" className="btn btn-secondary btn-sm">
                                    Delete</button>
                    </Link>  
                </div> 
            </td>
        </tr>
    )}
}
