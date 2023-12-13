<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unityproject";

//submitted inputs by user

$loginUser = $_POST["loginUser"];
$loginPass = $_POST["loginPass"];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
echo "Successfully connected";

$sql = "SELECT username FROM users WHERE username = '" . $loginUser . "'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  echo "Username is already taken";
} else {
  echo "creating user";
  $sql2 = "INSERT INTO users (username, password)
VALUES ('" . $loginUser . "', '" . $loginPass . "')";
  if ($conn->query($sql2) === TRUE) {
  echo "New record created successfully";
} else {
  echo "Error: " . $sql . "<br>" . $conn->error;
}
}
$conn->close();
?>