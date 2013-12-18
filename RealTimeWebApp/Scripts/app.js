$(document).ready(function () {
    $(function () {
        var chat = $.connection.chatHub;
        var productHub = $.connection.productsHub;

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

        productHub.client.updateProducts = function (products) {
            populateGrid(products);
        }


        $.connection.hub.start()
            .done(function () {
                initProducts();
                initChat();
            })
            .fail(function () {
                console.log("Nie udalo sie");
            });

        function initProducts() {
            return productHub.server.getAllProducts()
                .done(function (products) {
                    populateGrid(products);
                })
                .fail(function () {

                });
        };

        function initChat() {
            $('#sendButton').click(function () {
                var nick = $('#nickHolder').val();
                var message = $('#message-holder').val();
                chat.server.sendMessage(nick, message);
                $('#message-holder').val('').focus();
            });
        };
        
        function populateGrid(products) {
            $.each(products, function (index, value) {
                $('#productsHolder').html('');
                $('#productsHolder').append(
                    '<div id="' + (index + 1) + '" class="col-md-4">' +
                        '<h2>' + value.Name + '</h2>' +
                        '<p class="font-size-16">' + value.Desc + '</p>' +
                        '<p class="font-size-20">' + value.Price + '</p>' +
                        '<div class="pull-left">' +
                            '<div>' + value.UpVote + '</div>' +
                            '<a id=' + (index + 1) + ' href="#" class="good"><img id=' + (index + 1) + ' src="../Content/img/up.png" width="32" height="32" /></a>' +
                        '</div>' +
                        '<div class="pull-right">' +
                            '<div>' + value.DownVote + '</div>' +
                            '<a id=' + (index + 1) + ' href="#" class="bad"><img id=' + (index + 1) + ' src="../Content/img/down.png" width="32" height="32" /></a>' +
                        '</div>' +
                    '</div>'
                );
            });

            $('.good').click(function (e) {
                var id = e.target.id;
                productHub.server.updateVotes(id - 1, true);
            });
            $('.bad').click(function (e) {
                var id = e.target.id;
                productHub.server.updateVotes(id - 1, false);
            });
        };

    });
});