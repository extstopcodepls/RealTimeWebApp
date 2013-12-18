$(document).ready(function () {
    $(function () {
        var chat = $.connection.chatHub;
        $.connection.hub.logging = true;
        chat.client.updateChat = function (name, message) {
            var encMessage = $('<div />').text(message).html();
            var encName = $('<div />').text(name).html();
            $('#message-list').append('<li id="1" class="list-item-gray"> ' +
                                            '<div class="pull-left padding-right-10 font-bold">' + name + ':</div>' +
                                            '<div class="pull-left padding-right-15 wrapword">' + message + '</div>' +
                                            '<div class="clearfix"></div>' +
                                      '</li>');
        };

        $.connection.hub.start()
            .done(function () {
                $('#sendButton').click(function () {
                    var nick = $('#nickHolder').val();
                    var message = $('#message-holder').val();
                    chat.server.sendMessage(nick, message);
                    $('#message-holder').val('').focus();
                });
            })
            .fail(function () {
                console.log("Nie udalo sie");
            });
    });
});