# Inventory Management System (C++)

A robust console-based application designed to streamline the tracking and management of product stock. This system allows businesses or individuals to maintain a digital record of their inventory, ensuring efficient stock monitoring through persistent data storage and an intuitive command-line interface.

---

## 📝 Project Description
The **Inventory Management System** is a C++ project focused on managing product data, including stock levels, pricing, and item details. Built with a focus on data persistence, it utilizes File Handling (I/O) to ensure that inventory records are saved even after the program is closed. 

This project demonstrates the practical application of C++ fundamentals such as **Object-Oriented Programming (OOP)**, file streams (`fstream`), and structured data management. It is designed to minimize manual record-keeping errors and provide quick access to stock information.

---

## ✨ Key Features
* **Full CRUD Operations:**
    * **Add Item:** Register new products with unique IDs, names, quantities, and prices.
    * **View Inventory:** Display a complete list of all items currently in stock in a formatted table.
    * **Update Stock:** Modify existing product details or update quantities after restock/sales.
    * **Delete Product:** Remove discontinued or out-of-stock items from the database.
* **Persistent Data Storage:** Uses C++ file handling to save inventory data to a `.txt` file, ensuring no data loss between sessions.
* **Search Functionality:** Quickly locate specific products using their unique Product ID.
* **Clean Console UI:** Features a structured and readable output format for better user experience.

---

## 📊 Inventory Data Structure
Each item in the system is managed with the following attributes:

| Attribute | Description |
| :--- | :--- |
| **Product ID** | A unique numerical identifier for each item. |
| **Product Name** | The name or label of the product. |
| **Quantity** | The number of units currently available in stock. |
| **Price** | The unit price of the product. |

---

## 🚀 Getting Started

### Prerequisites
* A C++ compiler (e.g., GCC/MinGW, Clang, or MSVC).
* A terminal or command prompt.

### Installation & Execution
1. **Clone the repository:**
   ```bash
   git clone [https://github.com/sshihabb007/Inventory_Management_System_C-.git](https://github.com/sshihabb007/Inventory_Management_System_C-.git)
Navigate to the project directory:

Bash
cd Inventory_Management_System_C-
Compile the source code:

Bash
g++ "Inventory Management System.cpp" -o InventorySystem
Run the application:

Bash
./InventorySystem
🛠️ Technologies Used
Language: C++

Library: fstream (File I/O for database simulation)

Paradigm: Procedural & Object-Oriented Programming

📁 Repository Structure
Inventory Management System.cpp: The core source code containing logic for inventory operations.

Inventory Management System.pptx: A presentation detailing the project's design and logic.

record.txt: (Auto-generated) The text-based database file where product records are stored.
