<template>
    <div>
        channel: <b-form-input v-model="hue" id="nameInput" :style="`color:hsl(${color}, 100%, 50%)`"></b-form-input>
    </div>
</template>

<script>
    export default {
        computed: {
            hue: {
                get () {
                    return this.$store.getters.server;
                },
                set (value) {
                    this.$store.commit('setChannel', value);
                }
            }
        }
    }
</script>

<style lang="scss">
    #colorRange{
        width: 20vw;
        margin-left: -5vw;
    }
</style>