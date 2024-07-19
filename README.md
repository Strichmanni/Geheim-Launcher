# Geheim-Launcher

Geheim-Launcher is a simple application that helps you launch all installed applications on your device. This README provides instructions on how to install and use the application on Windows and Linux.

## Features

- Launch all installed applications on your device.
- Easy to use and set up.

## Installation

### Windows

1. **Clone the Repository**:
    ```sh
    git clone https://github.com/Strichmanni/Geheim-Launcher.git
    cd Geheim-Launcher
    ```

2. **Build the Application**:
    - Open a terminal or Command Prompt.
    - Navigate to the project directory:
        ```sh
        cd GeheimLauncher
        ```
    - Build the project:
        ```sh
        dotnet build
        ```

3. **Run the Application**:
    - After building, navigate to the output directory:
        ```sh
        cd bin/Debug/net6.0
        ```
    - Run the application:
        ```sh
        GeheimLauncher.exe
        ```

### Linux (using Wine)

1. **Install Wine**:
    - On Debian-based systems (like Ubuntu):
        ```sh
        sudo apt update
        sudo apt install wine
        ```
    - On Red Hat-based systems (like Fedora):
        ```sh
        sudo dnf install wine
        ```

2. **Clone the Repository**:
    ```sh
    git clone https://github.com/StrichManni/Geheim-Launcher.git
    cd Geheim-Launcher
    ```

3. **Build the Application**:
    - Open a terminal.
    - Navigate to the project directory:
        ```sh
        cd GeheimLauncher
        ```
    - Build the project:
        ```sh
        dotnet build
        ```

4. **Run the Application using Wine**:
    - After building, navigate to the output directory:
        ```sh
        cd bin/Debug/net6.0
        ```
    - Run the application with Wine:
        ```sh
        wine GeheimLauncher.exe
        ```

## Usage

1. **Starting the Application**:
    - On Windows, double-click `GeheimLauncher.exe` or run it from the terminal as described above.
    - On Linux, use Wine to start the application.

2. **Launching Applications**:
    - The application will automatically scan your Program Files directories and attempt to launch all installed applications.
    - You will see a list of started applications in the console.

3. **Exiting the Application**:
    - The application will wait for a key press to exit. Simply press any key to close the application.

## Contributing

If you have suggestions for improving the Geheim-Launcher or find bugs, please open an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.
