import React from "react";

export default class DeletePlayer extends React.Component<any,any>{

    componentDidMount(){
        const { id } =this.props.match.params;

        fetch('https://localhost:5001/api/player/' + id,{
            method: "DELETE",
            mode: "same-origin",
            cache: "default",
            credentials: "same-origin",
            headers: {
                "Content-Type": "application/json",
            },
            redirect : 'follow',
            referrerPolicy : 'no-referrer',
        })
        .catch(error => console.log(error))
        .then(() => window.history.back());
    }

    public render(){
        return(
            <div>
                <h3>Deleting...</h3>
            </div>
        )
    }
}