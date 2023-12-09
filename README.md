# CircuitVision
 ![Static Badge](https://img.shields.io/badge/UOWD-CSIT%20321%20final%20project-blue)

CSCI321 Capstone Project of Team Legionnaires from the University of Wollongong Dubai.


CircuitVision is an augmented-reality learning app that allows users to visualize breadboard assembly through their phone.

# Key features
- Schematic Detection
- AR overlays for placemnet guidance
- Save progress and resume from last checkpoint
- Component recognition and information

# How to Install

## Prerequisites
Before you can run this project, you need to ensure that your system meets the following requirements:

### For Unity
- **Unity Editor**: [Specify the version].
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
git clone https://github.com/yourusername/yourrepository.git
```
3. **Unity Setup**
- Open the project in Unity.
- Switch the build platform to iOS in Unity’s Build Settings.

3. **XAMPP Setup**
- Install XAMPP from [XAMPP Download Link].
- Start Apache and MySQL services.

4. **Database Setup**
- Access phpMyAdmin at `http://localhost/phpmyadmin`.
- Create your project's database and import any necessary SQL files.

5. **API Setup**
- Place your PHP project files in the `htdocs` folder of XAMPP.
- Ensure the Unity project is configured to communicate with your local PHP API (adjust URLs/endpoints as needed).

6. **iOS Device Testing**
- Connect your iOS device.
- In Xcode, configure your developer account and provisioning profile.


