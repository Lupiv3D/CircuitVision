<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unityproject";

//user input
$Username = $_POST["Username"];
// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT projectID FROM userprojects WHERE username = '" . $Username . "'";

$result = $conn->query($sql);

if($result->num_rows > 0){
  $rows = array();
  while($row = $result->fetch_assoc()){
    $rows[] = $row;
  }

  echo json_encode($rows);
} else{
  echo "0 results";
}
$conn->close();


?>