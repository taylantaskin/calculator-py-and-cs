# Console-Based Calculator

A console-based calculator application that replicates the basic functionality of the Windows Calculator. The calculator supports basic arithmetic operations, square root calculations, and maintains a history of calculations in a JSON file.

## Features
- **Basic Arithmetic Operations**:
  - Addition (`+`)
  - Subtraction (`-`)
  - Multiplication (`*`)
  - Division (`/`)
- **Advanced Operations**:
  - Square Root (`√`)
- **History Management**:
  - Saves all calculations in a JSON file.
  - Displays the history of previous calculations in a user-friendly format.
- **Error Handling**:
  - Handles division by zero gracefully.
  - Validates numerical inputs to avoid invalid calculations.
  - Displays appropriate messages for invalid inputs.
- **User Interface**:
  - Interactive console-based menu:
    - Perform arithmetic operations.
    - Calculate square roots.
    - View calculation history.
    - Exit the application.

## Requirements
### Python Version
- Python 3.6 or higher.
- `json` module (built-in).

### C# Version
- .NET 6.0 SDK or higher.
- Newtonsoft.Json NuGet package (for JSON handling).

## Installation
### Python
1. Clone the repository:
   ```bash
   git clone <repository_url>
   cd console-calculator
