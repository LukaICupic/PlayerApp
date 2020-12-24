import React from "react";
import UserRow from "./UserRow";

export interface IState{
    players : IPlayer[];
    loading : boolean;
}

export interface IPlayer{
    id: number,
    firstname: string,
    lastname: string,
    managerName:string,
    clubName:string
}

export default class Index extends React.Component<any,IState>{
    constructor(props:any){
        super(props);

     this.state = {
        players : [],
        loading : true
    };
}

    componentDidMount(){
        fetch('https://localhost:5001/api/player')
        .then(res => res.json())
        .then(players => this.setState({players, loading : false}))
    }


    render(){
        return (
            <div>
                <h1>Players</h1>

                {this.state.loading && 
                <div>
                    Loading...
                </div>}

                <table className="table">
                    <thead>
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">First name</th>
                            <th scope="col">Last name</th>
                            <th scope="col">Manager</th>
                            <th scope="col">Club</th>                  
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.players.map(player => 
                            <UserRow key={player.id} player = {player}/>)}
                    </tbody>
                    </table>
            </div>
        );
    }
}