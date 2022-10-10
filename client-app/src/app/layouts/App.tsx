import React, {useState,useEffect} from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';

function App() {
  const [activities, setActivities] = useState([])
  
  useEffect(() => {
    axios.get('https://localhost:5001/api/Activities').then(value => {
      console.log(value)
      setActivities(value.data);
    })
  },[])
  
  return (
    <div>
      <Header as='h2' icon={'users'} content='reactivities' />
      <List>
          {activities.map((activity : any) => (
              <List.Item key={activity.id}>{activity.title}</List.Item>
          ))}
      </List>
    </div>
  );
}

export default App;
