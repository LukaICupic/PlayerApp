import React from "react";
import { IPlayer } from "./Player";


interface IState {
    player : IPlayer;
    managers : any[];
    clubs: any[];
    loading : boolean
}

export default class AddPlayer extends React.Component<any,IState>{
    constructor(props:any){
        super(props);


        this.onChangeFirstName = this.onChangeFirstName.bind(this);
        this.onChangeLastName = this.onChangeLastName.bind(this);
        this.onChangeFieldPosition = this.onChangeFieldPosition.bind(this);
        this.onSubmit = this.onSubmit.bind(this);
        this.handleClubChange = this.handleClubChange.bind(this);
        this.handleManagerChange = this.handleManagerChange.bind(this);

        this.state = {
            player : {
            firstName:"",
            lastName:"",
            fieldPosition:"",
            isHidden:false,
            clubId:0,
            managerId:0},
            managers: [],
            clubs:[],
            loading: true
        }
    }


    onChangeFirstName(e : React.ChangeEvent<HTMLInputElement>){
        this.setState((prev : any) => ({player : {...prev.player, firstName : e.target.value}}))
    }

    onChangeLastName = (e : React.ChangeEvent<HTMLInputElement>)=>{
        this.setState((prev : any) => ({player : {...prev.player, lastName : e.target.value}}))

    }

    onChangeFieldPosition = (e : React.ChangeEvent<HTMLInputElement>)=>{
        this.setState((prev : any) => ({player : {...prev.player, fieldPosition : e.target.value}}))

    }

    handleClubChange(e : React.ChangeEvent<HTMLSelectElement>) {
        this.setState((prev : any) => ({player : {...prev.player, clubId : new Number(e.target.value)}}))
       }

       handleManagerChange(e : React.ChangeEvent<HTMLSelectElement>) {
        this.setState((prev : any) => ({player : {...prev.player, managerId : new Number(e.target.value)}}))
       }

    onSubmit = (e : React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        console.log(this.state);

        const data = {
            firstName : this.state.player.firstName,
            lastName: this.state.player.lastName,
            fieldPosition: this.state.player.fieldPosition,
            managerId : this.state.player.managerId,
            clubId : this.state.player.clubId
        }

        console.log(data);

        fetch('https://localhost:5001/api/player',{
            method: "POST",
            mode: "same-origin",
            cache: "default",
            credentials: "same-origin",
            headers: {
                "Content-Type": "application/json",
            },
            redirect : 'follow',
            referrerPolicy : 'no-referrer',
            body : JSON.stringify(data)
        })
        .then(res=> console.log(res))
        .catch(error => console.log(error))
        .then(() => window.history.back());
    }

    componentDidMount(){
        Promise.all([        
            fetch('https://localhost:5001/api/manager',{
                method: "GET",
                mode: "cors",
                cache: "no-cache",
                credentials: "same-origin",
                headers: {
                    "Content-Type": "application/json",
                },
                redirect: "follow",
                referrerPolicy: "no-referrer",
            }),
            fetch('https://localhost:5001/api/club', {
                method: "GET",
                mode: "cors",
                cache: "no-cache",
                credentials: "same-origin",
                headers: {
                    "Content-Type": "application/json",
                },
                redirect: "follow",
                referrerPolicy: "no-referrer",
            })
    ])
        .then(([res1, res2]) => Promise.all([res1.json(), res2.json()]))
        .then(([data1, data2]) => this.setState({
            managers : data1,
            clubs : data2,
            loading : false
        }))
        .catch(error => console.log(error))
    }
      
     

    render(){
        
        return(
            <div>
                <h1>Add new player</h1>

                {this.state.loading && 
                <div>
                    Loading...
                </div>}

                <form onSubmit={this.onSubmit}>          
                    <div className="form-group w-25">
                        <label htmlFor="firstName">First name</label>
                        <input required type="text" className="form-control" id="firstName"
                        value={this.state.player.firstName}
                        onChange={this.onChangeFirstName}/>                    
                    </div>
                    <div className="form-group w-25">
                        <label htmlFor="lastName">Last name</label>
                        <input required type="text" className="form-control" id="lastName"
                        value={this.state.player.lastName}
                        onChange={this.onChangeLastName}/>                      
                    </div>
                    <div className="form-group w-25">
                        <label htmlFor="fieldPosition">Field position</label>
                        <input required type="text" className="form-control" id="fieldPosition"
                        value={this.state.player.fieldPosition}
                        onChange={this.onChangeFieldPosition}/>                      
                    </div>
                    <div className="form-group w-25">
                        <label htmlFor="managers">Managers</label>
                        <select required className="form-control" id="managers" onChange={this.handleManagerChange}>
                        <option value="">Please select a manager</option>
                            {this.state.managers.map((manager : any) => 
                                <option key={manager.id} value={manager.id}>{manager.name}</option>)}
                        </select>
                    </div>
                    <div className="form-group w-25">
                    
                        <label htmlFor="clubs">Clubs</label>
                        <select required className="form-control" id="clubs" onChange={this.handleClubChange}>
                            <option value="" >Please select a club</option>
                            {this.state.clubs.map((club : any) =>
                                <option key={club.id} value={club.id}>{club.name}</option>)}
                        </select>
                    </div>
                    <button type="submit" className="btn btn-primary">Submit</button>
                </form>
            </div>
        )
    }
}