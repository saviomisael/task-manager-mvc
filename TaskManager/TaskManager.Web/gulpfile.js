const { src, dest, watch } = require("gulp");
const cleanCSS = require("gulp-clean-css");
const rename = require("gulp-rename");
const sourcemaps = require("gulp-sourcemaps");
const uglify = require("gulp-uglify");

const minifyCSS = () => {
    return src("wwwroot/css/styles/*.css")
        .pipe(cleanCSS())
        .pipe(rename({ extname: ".min.css" }))
        .pipe(dest("wwwroot/css/"));
}

const minifyJS = () => {
    return src("wwwroot/js/scripts/*.js")
        .pipe(sourcemaps.init())
        .pipe(uglify())
        .pipe(rename({ extname: ".min.js" }))
        .pipe(sourcemaps.write())
        .pipe(dest("wwwroot/js/"))
}

const defaultTask = () => {
    watch("wwwroot/css/styles/*.css", minifyCSS);
    watch("wwwroot/js/scripts/*js", minifyJS);
}

exports.default = defaultTask;
exports.minifyCSS = minifyCSS;
exports.minifyJS = minifyJS;