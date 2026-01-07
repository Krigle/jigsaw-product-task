// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener("DOMContentLoaded", function () {
  const currencySelect = document.getElementById("currency-select");
  const rates = {
    USD: 1,
    GBP: 0.73,
    EUR: 0.85,
  };
  const symbols = {
    USD: "$",
    GBP: "£",
    EUR: "€",
  };

  function updatePrices(currency) {
    const priceElements = document.querySelectorAll(".price");
    priceElements.forEach((el) => {
      const usdPrice = parseFloat(el.dataset.price);
      const converted = usdPrice * rates[currency];
      el.textContent = symbols[currency] + converted.toFixed(2);
    });
  }

  currencySelect.addEventListener("change", function () {
    updatePrices(this.value);
  });

  // Initial load
  updatePrices("USD");
});
