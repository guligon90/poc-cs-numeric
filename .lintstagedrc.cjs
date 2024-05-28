const config = {
    "*.cs": "dotnet format --verbosity=detailed",
    "./**/*.{js,jsx,ts,tsx,json,css,scss,md}": ["prettier --write"],
    "./**/*.+(js,jsx,ts,tsx,json,css,scss,md)": ["eslint"],
};

module.exports = config;
