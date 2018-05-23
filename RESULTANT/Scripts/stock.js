//Отрисовка ячеек с данными
function renderStock(result) {

    var container = $('<div>', { class: 'stockcont' });
    container.append($('<div>', { class: 'headerstock', text: result.Name }));
    container.append($('<div>', { class: 'volumestock', text: 'Цена: ' + result.Volume }));
    container.append($('<div>', { class: 'amountstock', text: 'Количество: ' + parseFloat(result.Price.Amount).toFixed(2) }));
    container.appendTo("#stockarray");
}

function getStocks() {
    $("#stockarray").empty()//очищаем область с данными
    $.ajax({
        dataType: "json",
        url: "/Stock/GetStocks"//получаем новые данные с сервера
    }).done(function (data) {
        data.forEach(function (item) {
            renderStock(item);//заполняем область новыми данными
        });


    });
}

