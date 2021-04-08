var myMixin = {
    created: function () {
        console.log('mixin created');

    },
    methods: {
        getUrlParameter: function (name) {
            name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
            var regex = new RegExp("[\\?&]" + name + "=([^&#]*)");
            var results = regex.exec(location.search);
            return results === null
                ? ""
                : decodeURIComponent(results[1].replace(/\+/g, " "));
        },
        pageBack: function () {
            window.history.go(-1);
            return false;
        }
    }
}

// Vue.mixin({
//     created: function() {

//     },
//     methods: {

//     }
// })