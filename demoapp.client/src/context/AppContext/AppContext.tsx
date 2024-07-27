import React, { createContext, useState, useEffect, ReactNode } from 'react';
import axios from 'axios';
import { Order, User } from '../../types';

interface AppContextProps {
  users: User[];
  orders: Order[];
  selectedUserId: number | null;
  selectUser: (id: number) => void;
}

const AppContext = createContext<AppContextProps | undefined>(undefined);

const AppProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
  const [users, setUsers] = useState<User[]>([]);
  const [orders, setOrders] = useState<Order[]>([]);
  const [selectedUserId, setSelectedUserId] = useState<number | null>(null);

  const apiBaseUrl = process.env.REACT_APP_API_BASE_URL;
  console.log("API Base URL:", apiBaseUrl);

  const fetchUsers = async () => {
    try {
      const response = await axios.get<User[]>(`${apiBaseUrl}/api/users`);
      setUsers(response.data);
    } catch (error) {
      console.error('Failed to fetch users:', error);
    }
  };

  const fetchOrders = async (userId: number) => {
    try {
      const response = await axios.get<Order[]>(`${apiBaseUrl}/api/users/${userId}/orders`);
      setOrders(response.data);
    } catch (error) {
      console.error('Failed to fetch orders:', error);
    }
  };

  useEffect(() => {
    fetchUsers();
  }, []);

  useEffect(() => {
    if (selectedUserId !== null) {
      fetchOrders(selectedUserId);
    }
  }, [selectedUserId]);

  const selectUser = (id: number) => {
    setSelectedUserId(id);
  };

  return (
    <AppContext.Provider value={{ users, orders, selectedUserId, selectUser }}>
      {children}
    </AppContext.Provider>
  );
};

export { AppProvider, AppContext };