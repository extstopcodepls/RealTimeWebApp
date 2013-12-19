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
            showMessageSender(name);
        };

        productHub.client.updateProducts = function (products) {
            populateGrid(products);
            populateTable(products);
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
                    populateTable(products);

                    $('#addProduct').click(function () {
                        addNewProduct();
                    });

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


        function populateTable(products) {
            $('tbody').html('');
            $.each(products, function (index, value) {
                $('tbody').append(
                    '<tr>' +
                        '<td>' + value.Id + '</td>' +
                        '<td>' + value.Name + '</td>' +
                        '<td>' + value.Desc + '</td>' +
                        '<td>' + value.Price + '</td>' +
                        '<td>' + value.UpVote + '</td>' +
                        '<td>' + value.DownVote + '</td>' +
                        '<td><button id="' + value.Id + '" type="button" class="btn btn-primary resetButton">Reset</button>' +
                        '<td><button id="' + value.Id + '" type="button" class="btn btn-primary removeButton">Remove</button>' +
                    '</td>'
                );
            });

            $('.resetButton').click(function (e) {
                var id = e.target.id;
                productHub.server.resetUpvotes(id);
            });

            $('.removeButton').click(function (e) {
                var id = e.target.id;
                productHub.server.removeProduct(id);
            });

        };

        function populateGrid(products) {
            $('#productsHolder').html('');
            $.each(products, function (index, value) {
                $('#productsHolder').append(
                    '<div class="col-md-4">' +
                        '<h2>' + value.Name + '</h2>' +
                        '<div class="height-120px">' +
                            '<p class="font-size-16 height-70px">' + value.Desc + '</p>' +
                            '<p class="font-size-20">' + value.Price + '</p>' +
                        '</div>' +
                        '<div class="pull-left">' +
                            '<div>' + value.UpVote + '</div>' +
                            '<a href="#" class="good"><img id=' + value.Id + ' src="../Content/img/up.png" width="32" height="32" /></a>' +
                        '</div>' +
                        '<div class="pull-right">' +
                            '<div>' + value.DownVote + '</div>' +
                            '<a href="#" class="bad"><img id=' + value.Id + ' src="../Content/img/down.png" width="32" height="32" /></a>' +
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

        function addNewProduct() {
            var productName = $('#productName').val();
            var productDescription = $('#productDesc').val();
            var productPrice = $('#productPrice').val();

            productHub.server.addProduct(productName, productDescription, productPrice);


        }

        function showMessageSender(name) {
            setInterval(function myfunction() {
                document.title = name + ' napisał!';
                setTimeout(function myfunction() {
                    document.title = '';
                }, 1000);
            }, 2000);
        };

    });
});