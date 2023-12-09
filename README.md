# CircuitVision
 ![Static Badge](https://img.shields.io/badge/UOWD-CSIT%20321%20final%20project-blue)

CSCI321 Capstone Project of Team Legionnaires from the University of Wollongong Dubai.


CircuitVision is an augmented-reality learning app that allows users to visualize breadboard assembly through their phone.

## Key features
- Schematic Detection
- AR overlays for placemnet guidance
- Save progress and resume from last checkpoint
- Component recognition and information

## Prerequisites
Before you can run this project, you need to ensure that your system meets the following requirements:

### For Unity
- **Unity Editor**: 2022.3.13f1.
- **For AR**:Apple ARKit package in unity. 
- **iOS Build Support**: Included in Unity installation.
- **Apple Developer Account**: Required for deploying to iOS devices.
- **Xcode**: For building and deploying to iOS.

### For iOS Development
- **Mac Computer**: With a recent version of macOS.
- **iOS Device**: For testing (e.g., iPhone or iPad).
- **Provisioning Profile and Certificates**: Set up in your Apple Developer account.

### For Database and Local Server
- **XAMPP**: For local server environment and PHP.
- **SQL Database**: MySQL (included in XAMPP).
- **phpMyAdmin**: For database management (included in XAMPP).
- **Network Configuration**: Configured to allow communication between Unity and the server.

### For API Development
- **PHP**: For backend API development (included in XAMPP).

## Installation
Follow these steps to get your development environment set up:

1. **Clone the Repository**
```bash
git clone https://github.com/Lupiv3D/CircuitVision.git
```
2. **Unity Setup**
- Open the project in Unity.
- Switch the build platform to iOS in Unity’s Build Settings.
![iOS Build module is required](https://i.postimg.cc/76FQTpcK/Sw-itch-to-i-OS-Build.png)

3. **XAMPP Setup**
- Install XAMPP from [XAMPP](https://www.apachefriends.org/index.html).
- Start Apache and MySQL services.

  
![start Apache](https://github.com/Lupiv3D/CircuitVision/assets/118269650/e187f9b2-d491-4a72-a8c1-2461fb07fdd7)

![Start MySQL](https://github.com/Lupiv3D/CircuitVision/assets/118269650/8f905408-495a-4315-a6c2-9287ad233e58)

4. **Database Setup**
- Access phpMyAdmin at `http://localhost/phpmyadmin`.
- Import the database into the server to create the necessary tables.

5. **API Setup**
- Create a folder in `htdocs` and place your PHP project files.
- Ensure the Unity project is configured to communicate with your local PHP API (adjust URLs/endpoints as needed).
  - In the C# file(registration) change the URLs in each function.

6. **iOS Device Testing**
- Connect your iOS device.
- In Xcode, configure your developer account and provisioning profile.
![Provisioning profile is required](https://i.postimg.cc/gjrknLCV/xcode-Build.png)
- Build the Unity-iPhone project with the iOS device still connected


