MinBankoMat (My ATM)
MinBankoMat is a simple ATM simulator developed in C# as part of a vocational training program in .NET software development.
The purpose of this project is to practice fundamental C# concepts such as classes, loops, menus, user management, and file structure.

Purpose
This console application simulates a basic ATM environment where users can:
Log in
View their balance
Withdraw money
Transfer money between users
Change settings

Admins users can modify other useraccounts, change settings but also make their account invalid.


Features

User Login: Users log in with a username and password.

Admin Mode: A special login that gives access to user management functions.

Account Management: View balance and withdraw funds.

Menu System: Console-based navigation using switch-case structures.

Simple Data Storage: Users are stored in memory using lists (no database integration).


Project Structure

Program.cs – Entry point of the application

RunProgram.cs – Initializes and controls the program flow

Menu.cs – User interface for regular users

AdminMenu.cs – Interface for admin-specific functions

User.cs – Represents user data

UserManager.cs – Handles user-related logic and some cash withdrawal logic

CashManager.cs – Handles cash withdrawal logic

Inputs.cs – Utility class for input validation and reading

Author
RockerMaster404
