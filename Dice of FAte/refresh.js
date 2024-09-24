var randomNumber = Math.floor(Math.random() * 6) + 1;

var changedice = document.querySelectorAll("img")[0];

var changeNum = "images/dice"+randomNumber+".png";

document.querySelectorAll("img")[0].setAttribute("src", changeNum);


var randomNumber1 = Math.floor(Math.random() * 6)+1;

var changedice1 = document.querySelectorAll("img")[1];

var changeNum1 = "images/dice"+randomNumber1+".png";

document.querySelectorAll("img")[1].setAttribute("src", changeNum1);

if(randomNumber > randomNumber1){
    document.querySelector("h1").innerHTML = "😅Player 1 Wins!🙁";
}
else if(randomNumber < randomNumber1){
    document.querySelector("h1").innerHTML = "🙁Player 2 Wins!😅";
}
else{
    document.querySelector("h1").innerHTML = "😅Draw!😅";
}