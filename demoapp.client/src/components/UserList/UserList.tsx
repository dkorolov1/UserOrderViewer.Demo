import React from 'react';
import { Tooltip } from 'react-tooltip';
import styles from './UserList.module.css';
import useAppContext from '../../hooks/useAppContext';

const UserList: React.FC = () => {
  const { users, selectUser, selectedUserId } = useAppContext();

  return (
    <div className={styles.userList}>
      <h2>Users</h2>
      <ul>
        {users.map(user => (
          <li key={user.id}
              onClick={() => selectUser(user.id)}
              className={`${styles.userItem} ${selectedUserId == user.id ? styles.selected : ''}`}
              data-tooltip-id={`user-email-tooltip-${user.id}`}
              data-tooltip-content={user.email}>
            <span
              className={`${styles.statusCircle}
              ${user.isActive ? styles.active : styles.inactive}`}/>
            {user.firstName} {user.lastName}
            <Tooltip id={`user-email-tooltip-${user.id}`} />
          </li>
        ))}
      </ul>
    </div>
  );
};

export default UserList;