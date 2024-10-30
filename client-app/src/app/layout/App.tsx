import { observer } from 'mobx-react-lite';
import { useEffect } from 'react'
import { Container, } from 'semantic-ui-react';
import NavBar from './NavBar';
import ActivityDashboad from '../features/activities/dashboard/ActivityDashboard';
import LoadingComponent from './LoadingComponent';
import { useStore } from '../stores/store';



export default observer(function App() {
  const {activityStore} = useStore();

  useEffect(() => {
    activityStore.loadActivities();
  }, [activityStore])

  if(activityStore.loadingInitial) return <LoadingComponent content='Cargando app'/>

  return (
    <>
      <NavBar />
      <Container style={{marginTop: '7em'}}>
        <ActivityDashboad />
      </Container>
      
    </>
  )
});
