var workModule = (function () {
    var selectors = {
        badge: "#badge"
    };

    function onGetStateClick(element) {
        var url = $(element).data("href");

        $.ajax({
            url: url,
            type: "GET",
            dataType: "json",
            success: (data) => {
                updateState(data.result);
            },
            error: (data) => {
                console.log(data);
            }
        });
    }

    function updateState(state) {
        $(selectors.badge).text(state);
    }

    return {
        onGetStateClick: onGetStateClick
    }
})(jQuery);