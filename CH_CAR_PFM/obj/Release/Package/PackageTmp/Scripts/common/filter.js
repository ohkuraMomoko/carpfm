Vue.filter('amountAddDot', function (num) {
    var source = String(num).split(".");
    source[0] = source[0].replace(
        new RegExp("(\\d)(?=(\\d{3})+$)", "ig"),
        "$1,"
    );
    return source.join(".");
})