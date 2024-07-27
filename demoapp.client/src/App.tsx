import React from 'react';
import styles from './App.module.css';
import { AppProvider } from './context/AppContext';
import UserList from './components/UserList/UserList';
import OrderList from './components/OrderList/OrderList';

const App: React.FC = () => {
  return (
    <AppProvider>
      <div className={styles.container}>
        <div className={styles.usersSection}>
          <UserList />
        </div>
        <div className={styles.ordersSection}>
          <OrderList />
        </div>
      </div>
    </AppProvider>
  );
};

export default App;