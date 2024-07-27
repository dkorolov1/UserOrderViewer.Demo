import React from 'react';
import useAppContext from '../../hooks/useAppContext';
import styles from './OrderList.module.css';
import { formatDate } from '../../utils/date-utils';

const OrderList: React.FC = () => {
  const { orders } = useAppContext();

  const toStatusClass = (status: string) => {
    switch (status) {
      case 'Shipped':
        return styles.shipped;
      case 'Pending':
        return styles.pending;
      case 'Delivered':
        return styles.delivered;
      default:
        return '';
    }
  };

  return (
    <div className={styles.orderList}>
      <h2>Orders</h2>
      <table className={styles.orderTable}>
        <thead>
          <tr>
            <th>Amount</th>
            <th>Date</th>
            <th>Status</th>
          </tr>
        </thead>
        <tbody>
          {orders.map(order => (
            <tr key={order.id}>
              <td>${order.amount.toFixed(2)}</td>
              <td>{formatDate(order.date)}</td>
              <td className={toStatusClass(order.status)}>{order.status}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default OrderList;