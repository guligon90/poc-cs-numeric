const config = {
    trailingComma: "es6",
    tabWidth: 4,
    semi: false,
    singleQuote: true,
    overrides: [
        {
            "files": ["**/*.html"],
            "options": {
                "printWidth": 150
            }
        }
    ]
};

module.exports = config;
