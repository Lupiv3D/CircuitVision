<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unityproject";

// Retrieve data from the POST request
$Username = $_POST["Username"];
$projectID = $_POST["projectID"];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// Prepare the SQL statement to prevent SQL injection
$stmt = $conn->prepare("INSERT INTO userprojects (username, projectID) VALUES (?, ?)");
$stmt->bind_param("si", $Username, $projectID);



// Execute the query
if ($stmt->execute() === TRUE) {
    echo "New record created successfully";
} else {
    echo "Error: " . $stmt->error;
}

// Close statement and connection
$stmt->close();
$conn->close();
?>