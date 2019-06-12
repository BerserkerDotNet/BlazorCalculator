window.BlazorCalculator = window.BlazorCalculator || {};

window.BlazorCalculator.keyPressHandlers = [];
window.BlazorCalculator.Utils = {
    registerkeyPressed: function (component) {
        window.BlazorCalculator.keyPressHandlers.push(component);
        document.body.onkeydown = function (a) {
            window.BlazorCalculator.keyPressHandlers.forEach(h => {
                h.invokeMethod("OnKeyPressed", a.key);
            });
        };
    }
}