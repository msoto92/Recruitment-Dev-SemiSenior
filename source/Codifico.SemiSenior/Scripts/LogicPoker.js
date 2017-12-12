
function ValidateCard() {
        

    $.ajax
    ({
        url: GetPath(),
        type: "GET",
        datatype: "json",
        success: function (json) {
            LoadImage(json)
            $('#Estadistica').text(Mecanic(json))
            LoadResumen(json)
        },
        error: function (x, st) {
            alert('Error al cargar las cartas.');
        }
    }
    );

}


    
function LoadImage(json) {

    for (var i = 0; i < json.ListCard.length; i++) {
        $('#image' + i).removeAttr("src");
        $('#image' + i).attr("src", "Content/cards/" + json.ListCard[i].ImageName);
    }

}

function LoadResumen(json) {
    var Text = "";
    var Div = "<div>"
    for (var i = 0; i < json.ListResumen.length; i++) {
        Div += "<div class='col-md-1'> <img src='Content/cards/"+json.ListResumen[i].ImageName+"' style='width:100%' /> </div>"
    }
    Div += "</div>";
    $('#resumen').html(Div);
}

function Mecanic(json) {
    var Text = "";

    if (validateColor(json)) {
        Text += "Color SI, ";
    }
    else {
        Text += "Color NO, "
    }

    if (validateStairs(json)) {
        Text += "Escalera SI, "
    }
    else {
        Text += "Escalera NO, "
    }

    Text += validateFrequency(json)

    return Text;
}

function validateStairs(json) {
    json = bubble(json);

    for (var i = 0; i < json.ListCard.length - 1; i++) {

        if (json.ListCard[i].Number + 1 !== json.ListCard[i + 1].Number) {

            // Validacion de A como uno 1
            if (json.ListCard[i + 1] === 14 && json.ListCard[0].Number === 2 && json.ListCard.length - 1 === i + 1) {
                return true;
            }
            else {
                return false;
            }
        }
    }

    return true;

}

function validateColor(json) {
    var SymbolInit = json.ListCard[0].Symbol;

    for (var i = 1; i < json.ListCard.length; i++) {
        if (SymbolInit !== json.ListCard[i].Symbol) {
            return false;
        }
    }
    return true;
}

function bubble(json) {
    for (var i = 0; i < json.ListCard.length ; i++) {

        for (var j = 0; j < json.ListCard.length - 1 ; j++) {
            if (json.ListCard[j].Number > json.ListCard[j + 1].Number) {
                var tmp = json.ListCard[j + 1];
                json.ListCard[j + 1] = json.ListCard[j];
                json.ListCard[j] = tmp;
            }
        }
    }
    return json
}


function validateFrequency(json) {

    var repeated = []
    var countRepeated = []

    for (var i = 0; i < json.ListCard.length; i++) {
        var count = 0;
        var findNumber = false;

        for (var j = 0; j < json.ListCard.length; j++) {

            if (json.ListCard[i].Number === json.ListCard[j].Number) {
                count++;
            }
        }

        if (count > 1 && repeated.indexOf(json.ListCard[i].Number) === -1) {
            repeated.push(json.ListCard[i].Number);
            countRepeated.push(count);
        }

    }

    var pair = 0;
    var trio = 0;
    var poker = 0;
    for (var i = 0; i < countRepeated.length; i++) {

        if (countRepeated[i] === 2) {
            pair++;
        } else if (countRepeated[i] === 3) {
            trio++;
        } else if (countRepeated[i] === 4) {
            poker++;
        }
    }

    if (poker > 0) {
        return "Poker SI, ";
    }
    else {
        return "Pares: " + pair + " Trios: " + trio + ", ";
    }

}

function GetPath() {
    var urlService = window.location.href.split('/');

    urlService[urlService.length - 1] = "/api/poker/GetCards";

    var urlText = ""

    for (var i = 0; i < urlService.length; i++) {
        urlText += urlService[i]+"//";
    }

    return urlText;
}