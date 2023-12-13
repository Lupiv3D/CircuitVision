<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unityproject";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$projectName = $_POST['projectName'];
//$projectID = $_POST['projectID']; // If you're also considering the username

// Prepare and bind
$stmt = $conn->prepare("UPDATE images SET current_step = current_step + 1 WHERE name = ?");
$stmt->bind_param("s", $projectName);

// Execute and check
if ($stmt->execute()) {
    echo "Current step updated successfully for project: " . $projectName;
} else {
    echo "Error: " . $stmt->error;
}

$stmt->close();
$conn->close();
?>