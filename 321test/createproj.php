<?php
// Connection and other logic here
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
// Connection and other logic here

$projectName = $_POST['projectName'];
$components = $_POST['components'];


$stmt = $conn->prepare("INSERT INTO images (name, components) VALUES (?,?)");
$stmt->bind_param("ss", $projectName, $components);

if ($stmt->execute()) {
    echo $conn->insert_id; // Returning the projectID
} else {
    echo "Error: " . $stmt->error;
}

$stmt->close();
$conn->close();
?>
