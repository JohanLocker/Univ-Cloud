function SendPost(Code, ControllerPost) {
    alertify.confirm("¿Seguro de que desea eliminar?",
        function () {
            let Data = {
                "Code": Code
            }
            $.ajax({
                type: "POST",
                url: ControllerPost,
                data: JSON.stringify(Data),
                contentType: "application/json; charset=utf-8",
                success: function () {
                    window.location.reload();
                    alert("Se elimino con exito", "Eliminado")
                },
                Error: function () {
                    alert('Error');
                }
            })
        }, function () {
        });
}
function alert2(message, title, buttonText) {

    buttonText = (buttonText == undefined) ? "Ok" : buttonText;
    title = (title == undefined) ? "The page says:" : title;

    var div = $('<div>');
    div.html(message);
    div.attr('title', title);
    div.dialog({
        autoOpen: true,
        modal: true,
        draggable: false,
        resizable: false,
        buttons: [{
            text: buttonText,
            click: function () {
                $(this).dialog("close");
                div.remove();
            }
        }]
    });
}