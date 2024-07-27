import { Order } from "../../types/Order";
import { User } from "../../types/User";

export interface AppContextType {
    users: User[];
    selectedUser: User | null;
    orders: Order[];
    setSelectedUser: React.Dispatch<React.SetStateAction<User | null>>;
}