function enviardatos(event) {
    event.preventDefault();
    const tipoFactura = document.getElementById("selectedRangeId").value;
    const tipodePago = document.getElementById("paymentMethod").value;
    const observacion = document.getElementById("observation").value
    console.log("tipoFactura:", tipoFactura);
    console.log("tipodePago:", tipodePago);
    console.log("observacion", observacion);

    const customerData = {
        tipoFactura: tipoFactura,
        tipodePago: tipodePago,
        observacion: observacion,
    };
    console.log("Objeto completo:", customerData);
}