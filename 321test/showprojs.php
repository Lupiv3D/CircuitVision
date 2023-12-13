<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unityproject";

//submitted inputs by user
/*
$loginUser = $_POST["loginUser"];
$loginPass = $_POST["loginPass"];*/
$projectID = $_POST["projectID"];


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}


$sql = "SELECT id, name FROM images WHERE id = '" . $projectID . "'";

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