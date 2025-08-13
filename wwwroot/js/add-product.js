let listProduct = [];
function showModal() {
    const modal = new bootstrap.Modal(document.getElementById("productModal"));
    const aceptButton = document.getElementById("capture");
    modal.show();
    aceptButton.addEventListener("click", function () {
        listProducts(listProduct);
        modal.hide();
    });
}
function captureProduct() {
    let product = document.getElementById("product").value;
    let amount = document.getElementById("amount").value;
    let items = {};
    
    switch (product) {
        case "LENTEN01":
            items = {
                code_reference: product,
                name: "Lencería Roja - Tentasión",
                price: 35000,
                quantity: amount,
                priceTotal: 35000 * amount
            }
            listProduct.push(items);
            showModal();
            break;
        case "POT02":
            items = {
                code: product,
                name: "Potenciadores - Black power",
                quantity: amount,
            }
            break;
        case "JUG03":
            items = {
                code: product,
                name: "Juguetes - Sen Intimo",
                quantity: amount,
            }
            break;
    }
}
function listProducts(obj) {
    document.getElementById("tableProducts").style.display = "block";
    document.getElementById("getProducts").innerHTML = "";
    
    for (var i = 0; i < obj.length; i++) {
        
        document.getElementById("getProducts").innerHTML += `
        <tr>
            <td>${obj[i].name}</td>
            <td>${obj[i].quantity}</td>
            <td>${obj[i].price}</td>
            <td>${obj[i].priceTotal}</td>
        </tr>
    `;
    }
}
