import json
import math

history_file = 'calculation_history.json'

def load_history():
    try:
        with open(history_file, 'r') as file:
            return json.load(file)
    except FileNotFoundError:
        return []

def save_history(history):
    with open(history_file, 'w') as file:
        json.dump(history, file, indent=4)

def add(x, y):
    return x + y

def subtract(x, y):
    return x - y

def multiply(x, y):
    return x * y

def divide(x, y):
    if y == 0:
        return "Error! Division by zero."
    return x / y

def square_root(x):
    if x < 0:
        return "Error! Cannot take the square root of a negative number."
    return math.sqrt(x)

def get_number(prompt):
    while True:
        try:
            return float(input(prompt))
        except ValueError:
            print("Invalid input! Please enter a valid number.")

def show_menu():
    print("\nCalculator Menu:")
    print("1. Perform basic Calculation")
    print("2. Calculate square root")
    print("3. View History")
    print("4. Exit")

def perform_basic_calculation():
    print("\nBasic Calculation Menu:")
    print("a. Add")
    print("b. Subtract")
    print("c. Multiply")
    print("d. Divide")
    basic_choice = input("Choose an operation : ")

    x = get_number("Enter first number: ")
    y = get_number("Enter second number: ")

    if basic_choice == 'a':
        result = add(x, y)
        print(f"Result: {result}")
        return f"Added {x} + {y} = {result}"
    elif basic_choice == 'b':
        result = subtract(x, y)
        print(f"Result: {result}")
        return f"Subtracted {x} - {y} = {result}"
    elif basic_choice == 'c':
        result = multiply(x, y)
        print(f"Result: {result}")
        return f"Multiplied {x} * {y} = {result}"
    elif basic_choice == 'd':
        result = divide(x, y)
        print(f"Result: {result}")
        return f"Divided {x} / {y} = {result}"
    else:
        print("Invalid choice! Returning to main menu.")
        return None

def user_choice():
    show_menu()
    choice = input("Choose an option: ")
    return choice

def handle_user_choice(history):
    while True:
        choice = user_choice()

        if choice == '1':
            calculation_result = perform_basic_calculation()
            if calculation_result:
                history.append(calculation_result)

        elif choice == '2':
            x = get_number("Enter number to find the square root: ")
            result = square_root(x)
            print(f"Result: {result}")
            history.append(f"Square root of {x} = {result}")

        elif choice == '3':
            print("\nHistory of calculations:")
            for entry in history:
                print(entry)

        elif choice == '4':
            save_history(history)
            print("Goodbye!")
            break

        else:
            print("Invalid choice! Please try again.")

def main():
    history = load_history()
    handle_user_choice(history)  

main()
